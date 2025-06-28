using Tomlyn;
using Tomlyn.Model;

var toml = @"
title = 'TOML Example'
[owner]
name = 'Tom'
dob = 1979-05-27T07:32:00-08:00
";

TomlTable model = Toml.Parse(toml).ToModel();

Console.WriteLine($"title: {model["title"]}");
var owner = model["owner"] as TomlTable;
Console.WriteLine($"owner.name: {owner?["name"]}");
Console.WriteLine($"owner.dob: {owner?["dob"]}");
