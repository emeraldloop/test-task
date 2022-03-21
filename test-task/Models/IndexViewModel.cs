namespace test_task.Models;

public class IndexViewModel
{
    public IEnumerable<Client> Clients { get; set; }
    public PageViewModel PageViewModel { get; set; }
    public FilterViewModel FilterViewModel { get; set; }
    public SortViewModel SortViewModel { get; set; }
}