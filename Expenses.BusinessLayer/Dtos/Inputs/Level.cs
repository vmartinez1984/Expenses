namespace Expenses.BusinessLayer.Dtos.Inputs
{
    public class LevelDto{
        public EnumLevel Level { get; set; } = EnumLevel.Simple;
        
        
    }

    public enum EnumLevel{
        Simple, Full
    }
}