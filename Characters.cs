public class Character
{
  public UInt64 Id { get; set; }
  public string? Name { get; set; }
  public List<string> Alias { get; set; } = [];
  public string? Description { get; set; }
  public string? Species { get; set; }
  public string? FirstAppearance { get; set; }
  public UInt16 YearCreated { get; set; }
  public List<string> Series { get; set; } = [];
  public string Display()
  {
    return $"Id: {Id}\nName: {Name}\nAlias: {string.Join(", ", Alias)}\nDescription: {Description}\nSpecies: {Species}\nFirst Appearance: {FirstAppearance}\nYear Created: {YearCreated}\nSeries: {string.Join(", ", Series)}\n";
  }
}