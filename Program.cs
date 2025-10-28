using System.Text.Json;

// deserialize mario json from file into List<Mario>
List<Character> dks = JsonSerializer.Deserialize<List<Character>>(File.ReadAllText("dk.json"))!;
// deserialize mario json from file into List<Mario>
List<Character> marios = JsonSerializer.Deserialize<List<Character>>(File.ReadAllText("mario.json"))!;
// combine all characters into 1 list
List<Character> characters = [];
characters.AddRange(dks);
characters.AddRange(marios);


// display all characters
Console.Clear();

// bool Character1995 = characters.Any(c => c.YearCreated == 1995);
// Console.WriteLine($"Are there characters created in 1995: {Character1995}");

// Console.WriteLine($"How many? {characters.Count(c => c.YearCreated == 1995)}");

// foreach(CharacterDTO characterDTO in characters.Where(c => c.YearCreated == 1995).Select(c => new CharacterDTO{ Id = c.Id, Name = c.Name, Series = c.Series }).OrderBy(c => c.Name))
// {
//   Console.WriteLine(characterDTO.Display());
// }

// // how many characters in total (all series)?
// int count1981 = characters.Count(c => c.YearCreated == 1981);
// Console.WriteLine($"1.There are {count1981} characters created in 1981 all series");

// how many characters in total (all series)?
int count1981 = characters.Count(c => c.YearCreated == 1981);
Console.WriteLine($"Here are {count1981} characters created in 1981 all series");

//List the character(s) created in that 1981 (all series) - return character name and series only.
var created1981Characters = characters
    .Where(c => c.YearCreated == 1981)
    .Select(c => new { c.Name, Series = string.Join(", ", c.Series) });

foreach (var character in created1981Characters)
{
    Console.WriteLine($"Name: {character.Name}, Series: {character.Series}");
}

//How many character(s) were created in 1981 (Mario series)
int count1981Mario = characters
    .Count(c => c.YearCreated == 1981 && c.Series.Contains("Mario"));
Console.WriteLine($"There are {count1981Mario} characters created in 1981 in the Mario series");

//List the character(s) created in that 1981 (Mario series) - return character name only.
var names1981Mario = characters
    .Where(c => c.YearCreated == 1981 && c.Series.Contains("Mario"))
    .Select(c => c.Name);

foreach (var name in names1981Mario)
{
    Console.WriteLine(name);
}

// How many character(s) were created in 1981 (Donkey Kong series)?
int count1981DonkeyKong = characters
    .Count(c => c.YearCreated == 1981 && c.Series.Contains("Donkey Kong"));
Console.WriteLine($"2.There are {count1981DonkeyKong} characters created in 1981 in the Donkey Kong series");

//List the character(s) created in that 1981 (Donkey Kong series) - return character name only.
var names1981DonkeyKong = characters
    .Where(c => c.YearCreated == 1981 && c.Series.Contains("Donkey Kong"))
    .Select(c => c.Name);

foreach (var name in names1981DonkeyKong)
{
    Console.WriteLine(name);
}

// How many character(s) made their first appearance in Donkey Kong 64?
int countDK64 = characters
    .Count(c => c.FirstAppearance == "Donkey Kong 64");

Console.WriteLine($"There are {countDK64} characters who made their first appearance in Donkey Kong 64.");

// List the character(s) that made their first appearance in Donkey Kong 64 - return character name only.
var namesDK64 = characters
    .Where(c => c.FirstAppearance == "Donkey Kong 64")
    .Select(c => c.Name);

foreach (var name in namesDK64)
{
    Console.WriteLine(name);
}

//Are there any character(s) with no alias (all series)?

var noAliasCharacters = characters
    .Where(c => c.Alias == null || !c.Alias.Any() || c.Alias.All(a => string.IsNullOrWhiteSpace(a)));

if (noAliasCharacters.Any())
{
    Console.WriteLine("There are characters with no alias:");
    foreach (var character in noAliasCharacters)
    {
        Console.WriteLine(character.Name);
    }
}
else
{
    Console.WriteLine("All characters have aliases.");
}

//How many character(s) with no alias (all series)?
int countNoAlias = characters
    .Count(c => c.Alias == null || !c.Alias.Any() || c.Alias.All(a => string.IsNullOrWhiteSpace(a)));

Console.WriteLine($"There are {countNoAlias} characters with no alias across all series.");

// List the character(s) with no alias (all series) - return character name, alias and series only.
var charactersWithoutAlias = characters
    .Where(c => c.Alias == null || !c.Alias.Any() || c.Alias.All(a => string.IsNullOrWhiteSpace(a)))
    .Select(c => new
    {
        c.Name,
        Alias = c.Alias == null ? "(null)" : string.Join(", ", c.Alias),
        Series = string.Join(", ", c.Series)
    });

foreach (var character in charactersWithoutAlias)
{
    Console.WriteLine($"Name: {character.Name}, Alias: {character.Alias}, Series: {character.Series}");
}

//  Are there any character(s) with no alias (Mario series)?
bool hasNoAliasMario = characters
    .Any(c => c.Series.Contains("Mario") && (c.Alias == null || !c.Alias.Any() || c.Alias.All(string.IsNullOrWhiteSpace)));

Console.WriteLine(hasNoAliasMario ? "Yes, there are Mario characters with no alias." : "No, all Mario characters have aliases.");

// Are there any character(s) with no alias (Mario series)?
// var noAliasMarioCharacters = characters
//     .Where(c => c.Series.Contains("Mario") && (c.Alias == null || !c.Alias.Any() || c.Alias.All(a => string.IsNullOrWhiteSpace(a))));
// if (noAliasMarioCharacters.Any())
// {
//     Console.WriteLine("There are Mario series characters with no alias:");
//     foreach (var character in noAliasMarioCharacters)
//     {
//         Console.WriteLine(character.Name);
//     }
// }
// else
// {
//     Console.WriteLine("All Mario series characters have aliases.");
// }

// How many character(s) with no alias (Mario series)?
int countNoAliasMario = characters
    .Count(c => c.Series.Contains("Mario") && (c.Alias == null || !c.Alias.Any() || c.Alias.All(string.IsNullOrWhiteSpace)));

Console.WriteLine($"how many character(s) with no alias (Mario series)? {countNoAliasMario}");

// List the character(s) with no alias (Mario series) - return character name and alias only.
var marioCharactersNoAlias = characters
    .Where(c => c.Series.Contains("Mario") && (c.Alias == null || !c.Alias.Any() || c.Alias.All(string.IsNullOrWhiteSpace)))
    .Select(c => new
    {
        c.Name,
        Alias = c.Alias == null ? "(null)" : string.Join(", ", c.Alias)
    });

foreach (var character in marioCharactersNoAlias)
{
    Console.WriteLine($"{character.Name}, Alias: {character.Alias}");
}


//  Are there any character(s) with no alias (Donkey Kong series)?
bool hasNoAliasDonkeyKong = characters
    .Any(c => c.Series.Contains("Donkey Kong") && (c.Alias == null || !c.Alias.Any() || c.Alias.All(string.IsNullOrWhiteSpace)));

Console.WriteLine(hasNoAliasDonkeyKong ? "Yes, there are Donkey Kong characters with no alias." : "No, all Donkey Kong characters have aliases.");

// how many character(s) with no alias (Donkey Kong series)?
int countNoAliasDonkeyKong = characters
    .Count(c => c.Series.Contains("Donkey Kong") && (c.Alias == null || !c.Alias.Any() || c.Alias.All(string.IsNullOrWhiteSpace)));

Console.WriteLine($"how many character(s) with no alias (Donkey Kong series)? {countNoAliasDonkeyKong}");

// List the character(s) with no alias (Donkey Kong series) - return character name and alias only.

var noAliasDonkeyKongCharacters = characters
    .Where(c => c.Series.Contains("Donkey Kong") && (c.Alias == null || !c.Alias.Any() || c.Alias.All(string.IsNullOrWhiteSpace)))
    .Select(c => new
    {
        c.Name,
        Alias = c.Alias == null ? "(null)" : string.Join(", ", c.Alias)
    });

foreach (var character in noAliasDonkeyKongCharacters)
{
    Console.WriteLine($"Name: {character.Name}, Alias: {character.Alias}");
}

// Do any character(s) have an alias of Snowmad King (return type must be boolean)?
bool hasSnowmadKingAlias = characters
    .Any(c => c.Alias != null && c.Alias.Contains("Snowmad King"));

Console.WriteLine($"Do any character(s) have an alias of Snowmad King? {hasSnowmadKingAlias}");

//  List the character(s) that have an alias of Snowmad King - return character name and alias only.
var snowmadKingCharacters = characters
    .Where(c => c.Alias != null && c.Alias.Contains("Snowmad King"))
    .Select(c => new
    {
        c.Name,
        Alias = string.Join(", ", c.Alias)
    });

foreach (var character in snowmadKingCharacters)
{
    Console.WriteLine($"Name: {character.Name}, Alias: {character.Alias}");
}
































































































































































































































































































































































































































