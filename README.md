[![](https://img.shields.io/nuget/v/Jumble.svg)](https://www.nuget.org/packages/Jumble) [![](https://img.shields.io/nuget/vpre/Jumble.svg)](https://www.nuget.org/packages/Jumble)

# Jumble
Simple password hashing library for .NET

## Installation
### Package Manager
`Install-Package Jumble`

### .NET CLI
`dotnet add package Jumble`

## Getting Started
Using Jumble is very simple. 

1. New up a hash generator.
```csharp
var hashGenerator = new HashGenerator();
```

2. Call the generate method passing the string you want to hash.
```csharp
var hash = hashGenerator.Generate(myPassword);
```

3. Call `ToString()` on the hash in order to store it in a database for later use.
```csharp
user.PasswordHash = hash.ToString();

db.SaveChanges();
```

4. Call the validate method on the hash generator to validate that the password string entered by the user matches the hash.
```csharp
if (hashGenerator.Validate(user.PasswordHash, password))
{
    // authenticate user
}
```

## Hash Generator
For simple use, the hash generator can be created with default options by calling the parameterless constructor.

The default options will run the hash 1000 times with a salt length of 32 bytes and hash length of 512 bytes.

```csharp
var defaultGenerator = new HashGenerator();

var hash = defaultGenerator.Generate(somePassword);
```

If you'd like to customize the options you can create a `HashGeneratorOptions` object to pass.

Here we create a new hash generator that runs 100 times with a resulting hash of 1024 bytes.
```csharp
var options = new HashGeneratorOptions(100, 1024);

var generator = new HashGenerator(options);

var hash = generator.Generate(somePassword);
```

By default this will still use a salt of 32 bytes. You can optionally pass a salt generator to the hash generator if you'd like to customize it.

The hash generator takes an interface for a salt generator, so you can use your own custom salt generator if you'd like.

Here we create a salt generator that will generate a salt 64 bytes in length to pass to our hash generator.
```csharp
var saltOptions = new SaltGeneratorOptions(64);

var saltGenerator = new SaltGenerator(saltOptions);

var options = new HashGeneratorOptions(100, 1024);

var hashGenerator = new HashGenerator(options, saltGenerator);

var hash = hashGenerator.Generate(somePassword);
```