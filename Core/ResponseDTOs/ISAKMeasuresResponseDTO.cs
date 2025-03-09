namespace Core.ResponseDTOs;

public class ISAKMeasuresResponseDTO
{
    public int Id { get; set; }

    // Skinfolds (mm)
    public float TricepsMm { get; set; }
    public float SubscapularMm { get; set; }
    public float BicepsMm { get; set; }
    public float IliacCrestMm { get; set; }
    public float SupraespinalMm { get; set; }
    public float AbdominalMm { get; set; }
    public float FrontThighMm { get; set; }
    public float MedialCalfMm { get; set; }

    // Perimeters (cm)
    public float RelaxedArmCm { get; set; }
    public float FlexedArmCm { get; set; }
    public float WaistCm { get; set; }
    public float HipCm { get; set; }
    public float MidThighCm { get; set; }
    public float CalfCm { get; set; }

    // Bone Diameters (cm)
    public float WristDiameterCm { get; set; }
    public float ElbowDiameterCm { get; set; }
    public float KneeDiameterCm { get; set; }

    // Body Measurements
    public float WeightKg { get; set; }
    public float TotalHeightMts { get; set; }
    public float WingspanCm { get; set; }
    public float FootLengthCm { get; set; }

    public DateOnly MeasureDate { get; set; }
    public int UserId { get; set; }
}