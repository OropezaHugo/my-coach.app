namespace Core.ResponseDTOs;

public class FoodResponseDTO
{
    public required int Id { get; set; }
    public required string FoodName { get; set; }
    public required string FoodGroup { get; set; }
    public required string FoodSubGroup { get; set; }
    public required double FoodEnergyKcal { get; set; }
    public required double FoodHumidityGr { get; set; }
    public required double FoodProteinGr { get; set; }
    public required double FoodFatGr { get; set; }
    public required double FoodCarbsGr { get; set; }
    public required double FoodFibberGr { get; set; }
    public required double FoodAshGr { get; set; }
    public required double FoodCalciumGr { get; set; }
    public required double FoodPhosphorusMg { get; set; }
    public required double FoodIronMg { get; set; }
    public required double FoodVitaminAMig { get; set; }
    public required double FoodVitaminB1Mg { get; set; }
    public required double FoodVitaminB2Mg { get; set; }
    public required double FoodVitaminB3Mg { get; set; }
    public required double FoodVitaminCMg { get; set; }
}
