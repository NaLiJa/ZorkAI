namespace Planetfall.Item.Lawanda.Lab;

public class LabUniform : OpenAndCloseContainerBase, ICanBeTakenAndDropped, ICanBeExamined, IAmClothing
{
    public override string[] NounsForMatching => ["lab uniform", "uniform"];

    public override bool IsTransparent => true;

    // If the player tries to put something in this uniform, put it in the pocket instead.
    public override ICanContainItems ForwardingContainer => Repository.GetItem<LabUniformPocket>();

    public override int Size => 3;

    public bool BeingWorn { get; set; } = false;

    public string ExaminationDescription =>
        "It is a plain lab uniform. The logo above the pocket depicts a flame burning above some kind of sleep " +
        $"chamber. The pocket is {(Repository.GetItem<LabUniformPocket>().IsOpen ? "open" : "closed")}. " +
        (Repository.GetItem<LabUniformPocket>().Items.Any() && Repository.GetItem<LabUniformPocket>().IsOpen
            ? $"\n{ItemListDescription("lab uniform", null)}"
            : "");

    public string OnTheGroundDescription(ILocation currentLocation)
    {
        return "There is a lab uniform here. " +
               (Repository.GetItem<LabUniformPocket>().Items.Any() && Repository.GetItem<LabUniformPocket>().IsOpen
                   ? $"\n{ItemListDescription("lab uniform", null)}"
                   : "");
    }

    public override string NeverPickedUpDescription(ILocation currentLocation)
    {
        return "Hanging on a rack is a pale blue lab uniform. Sewn onto its pocket is a nondescript logo. "
               + (Repository.GetItem<LabUniformPocket>().Items.Any() && Repository.GetItem<LabUniformPocket>().IsOpen
                   ? $"\n{ItemListDescription("lab uniform", null)}"
                   : "");
    }

    public override string GenericDescription(ILocation? currentLocation)
    {
        return "A lab uniform";
    }

    public override void Init()
    {
        StartWithItemInside<LabUniformPocket>();
    }
}