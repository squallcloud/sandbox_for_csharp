using Tomlyn;
using Tomlyn.Model;

// 文字列からパースするサンプル
var toml = @"
title = 'TOML Example'
[owner]
name = 'Tom'
dob = 1979-05-27T07:32:00-08:00
";

TomlTable model = Toml.Parse(toml).ToModel();

Console.WriteLine("=== String Sample ===");
Console.WriteLine($"title: {model["title"]}");
var owner = model["owner"] as TomlTable;
Console.WriteLine($"owner.name: {owner?["name"]}");
Console.WriteLine($"owner.dob: {owner?["dob"]}");

// ファイルからパースするサンプル
var filePath = "sample.toml";
if (File.Exists(filePath)) {
    var fileToml = File.ReadAllText(filePath);
    TomlTable fileModel = Toml.Parse(fileToml).ToModel();

    Console.WriteLine("\n=== File Sample ===");
    Console.WriteLine($"title: {fileModel["title"]}");
    var fileOwner = fileModel["owner"] as TomlTable;
    Console.WriteLine($"owner.name: {fileOwner?["name"]}");
    Console.WriteLine($"owner.dob: {fileOwner?["dob"]}");

    var tomlArray = fileOwner?["ports"] as TomlArray;
    if (tomlArray != null) {
        var hoge = tomlArray;
        foreach (Int64? portObj in hoge) {
            if (portObj is Int64 port) {
                Console.WriteLine($"owner.ports item (int): {port}");
            } else {
                Console.WriteLine($"owner.ports item (not int): {portObj}");
            }
        }
    }
} else {
    Console.WriteLine($"TOML file '{filePath}' not found.");
}
