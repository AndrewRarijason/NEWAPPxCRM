namespace new_app_dotnet.Models
{
    public class DashboardViewModel
    {
        public List<StatistiqueBudgetDto>? StatistiqueBudgets { get; set; }
        public DepenseStatDTO? DepenseStat { get; set; }
    }
}


namespace new_app_dotnet.Models
{
    public class ModifierTicketViewModel
    {
        public int DepenseId { get; set; }
        public decimal ValeurDepense { get; set; }
    }
}
