[![](https://img.shields.io/nuget/v/Jumble.svg)](https://www.nuget.org/packages/Jumble) [![](https://img.shields.io/nuget/vpre/Jumble.svg)](https://www.nuget.org/packages/Jumble)

# Jumble
Simple password hashing library for .NET

## Installation
### Package Manager
`Install-Package Jumble`

### .NET CLI
`dotnet add package Jumble`

### Getting Started
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

4. Use the parse function to convert the string back into a hash when you need to validate the user's password.
```csharp
var hash = PasswordHash.Parse(user.PasswordHash);
```

5. Call the validate method on the hash generator to validate that the password string entered by the user matches the hash.
```csharp
if (hashGenerator.Validate(hash, password))
{
    // authenticate user
}
```