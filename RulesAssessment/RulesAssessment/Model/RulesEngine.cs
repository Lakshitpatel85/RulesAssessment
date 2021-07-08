using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesAssessment.Model
{
  public class RulesEngine
  {
    public int CreditScore { get; set; }
    public decimal DecreaseIntresetRate { get; set; }
    public decimal IncreaseIntersetRate { get; set; }
    public List<string> DisqualifiedState { get; set; }
    public List<Product> AddIntersetRateProduct { get; set; }
  }
}
