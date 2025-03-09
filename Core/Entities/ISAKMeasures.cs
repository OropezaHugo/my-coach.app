using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ISAKMeasures: BaseEntity
{
    // Skinfolds (mm)
    public required float TricepsMm { get; set; }
    public required float SubscapularMm { get; set; }
    public required float BicepsMm { get; set; }
    public required float IliacCrestMm { get; set; }
    public required float SupraespinalMm { get; set; }
    public required float AbdominalMm { get; set; }
    public required float FrontThighMm { get; set; }
    public required float MedialCalfMm { get; set; }

    // Perimeters (cm)
    public required float RelaxedArmCm { get; set; }
    public required float FlexedArmCm { get; set; }
    public required float WaistCm { get; set; }
    public required float HipCm { get; set; }
    public required float MidThighCm { get; set; }
    public required float CalfCm { get; set; }

    // Bone Diameters (cm)
    public required float WristDiameterCm { get; set; }
    public required float ElbowDiameterCm { get; set; }
    public required float KneeDiameterCm { get; set; }

    // Body Measurements
    public required float WeightKg { get; set; }
    public required float TotalHeightMts { get; set; }
    public required float WingspanCm { get; set; }
    public required float FootLengthCm { get; set; }
    
    public DateOnly MeasureDate { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public User? User { get; set; }
}