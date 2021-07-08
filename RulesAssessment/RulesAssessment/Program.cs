using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RulesAssessment.Model;

namespace RulesAssessment
{
  class Program
  {
    static void Main(string[] args)
    {
      Person person = new Person();
      person.CreditScore = 720;
      person.State = "Florida";

      Product product = new Product();
      product.Name = "7 - 1 ARM";
      product.InterestRate = 5.0M;

      RulesEngine rulesEngine = loadRules();
      Product result =  runRules(person, product, rulesEngine);
      Console.WriteLine("Project Name: " + result.Name);
      Console.WriteLine("Project Interest Rate  " + result.InterestRate);
      Console.WriteLine("Project diqualified  " + result.Disqualified);
      Console.WriteLine("\npress any key to exit the process...");

     
      Console.ReadKey();
    }

    public static Product runRules(Person person, Product product, RulesEngine rulesEngine)
    {
      // Now here you can run the rules 
      if (rulesEngine.DisqualifiedState.Where(x=>x.ToLower() == person.State).FirstOrDefault() != null)
      {
        product.Disqualified = true;
      }
      else
      {
        product.Disqualified = false;
      }
      
      
      if (rulesEngine.CreditScore >= person.CreditScore)
      {
        product.InterestRate = product.InterestRate - rulesEngine.DecreaseIntresetRate;
      }
      else
      {
        product.InterestRate = product.InterestRate + rulesEngine.IncreaseIntersetRate;
      }

      Product objProduct = rulesEngine.AddIntersetRateProduct.Where(x => x.Name.ToLower() == product.Name.ToLower()).FirstOrDefault();
      if (objProduct != null)
      {
        product.InterestRate = product.InterestRate + objProduct.InterestRate;
      }
      
      return product;
    }

    public static RulesEngine loadRules()
    {
      RulesEngine r = new RulesEngine();
      r.CreditScore = 720;
      r.DecreaseIntresetRate = 0.3M;
      r.IncreaseIntersetRate = 0.5M;
      r.DisqualifiedState = new List<string> { "Florida", "New York" };
      List<Product> objProduct = new List<Product>();
      Product prd = new Product();
      prd.Name = "7 - 1 ARM";
      prd.InterestRate = 0.5M;
      prd.Disqualified = false;

      objProduct.Add(prd);
      r.AddIntersetRateProduct = objProduct;

      return r;
    }
  }
}
