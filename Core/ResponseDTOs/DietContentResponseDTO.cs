namespace Core.ResponseDTOs;

public class DietContentResponseDTO
{
    public required int DietId { get; set; }
    public required string DietName { get; set; }
    public required double WaterAmount { get; set; }
    public List<DietFoodGroupContentDTO> DietFoodGroupInfos { get; set; } = new List<DietFoodGroupContentDTO>();
}