namespace test_task.Models;

public enum SortState
{
    NameAsc,    // по имени по возрастанию
    NameDesc,   // по имени по убыванию
    DateAddAsc, // по дате добавления по возрастанию
    DateAddDesc,    // по дате добавления по убыванию
    DateUpdateAsc, // по дате обновления по возрастанию
    DateUpdateDesc, // по дате обновления по убыванию
    BusinessTypeAsc, // по типу бизнеса по возрастанию
    BusinessTypeDesc // по типу бизнеса по убыванию
}