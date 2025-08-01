# 🛍️ Amazon Review Generator

A C# application designed to generate realistic Amazon-style product reviews for testing, demo, or entertainment purposes.

## 📁 Project Structure

```text
AmazonReviewGenerator/
├── Amazon_Review_Generator/       # Core application logic
│   ├── Program.cs
│   ├── ReviewGenerator.cs
│   └── ... (other source files)
├── ReviewGeneratorTests/          # Unit tests
│   ├── ReviewGeneratorTests.cs
│   └── ... (test files)
├── Amazon_Review_Generator.sln    # Solution file
└── README.md                      # Project documentation
```

## 🚀 Features

- Generates randomized product reviews with configurable parameters
- Includes sample review templates and sentiment variations
- Built with extensibility in mind for future integrations (e.g., API endpoints or UI)

## 🧪 Testing

Unit tests are located in the `ReviewGeneratorTests` folder. To run them:

```bash
dotnet test ReviewGeneratorTests
```

🛠️ Technologies Used
C# (.NET)

HTML (for potential UI rendering)

Smalltalk (possibly for legacy or experimental components)

📥 Getting Started
Clone the repo:
```
git clone https://github.com/blanchardsw/AmazonReviewGenerator.git
cd AmazonReviewGenerator
```

Open Amazon_Review_Generator.sln in Visual Studio or run:
```
dotnet build
```

Run the generator:
```
dotnet run --project Amazon_Review_Generator
```

📄 License
This project is open-source. Feel free to fork, modify, and contribute!

🙋‍♂️ Author
Created by Stephen Blanchard
