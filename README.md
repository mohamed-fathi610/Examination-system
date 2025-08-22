# 🎓 Examination System (C# OOP Project)

## 📌 Overview
This project is a simple **Examination System** implemented in **C#** using **Object-Oriented Programming (OOP)** concepts.

The system allows creating different types of exams (**Practical** and **Final**) with multiple types of questions (**MCQ**, **True/False**).  
It simulates the process of creating an exam, taking it, and calculating grades.

---

## 🛠 Features
- **Question Types**:
  - Multiple Choice Questions (MCQ)
  - True/False Questions
- **Exam Types**:
  - Practical Exam → shows the correct answer after each question.
  - Final Exam → shows all questions, options, user answers, correct answers, and grade.
- **Subject** contains Exam(s).
- Supports:
  - `ToString()` overrides for better printing.
  - `ICloneable` (deep copy).
  - `IComparable` (comparison between objects).
  - Constructor chaining.

---

## 📂 Project Structure


---

## 🚀 How to Run
1. Open the project in **Visual Studio** (or any C# IDE).
2. Build the solution (`Ctrl+Shift+B`).
3. Run the program (`Ctrl+F5`).
4. Follow console instructions:
   - Choose exam type.
   - Enter exam duration and number of questions.
   - Define each question (body, options, correct answer).
   - Take the exam.
   - See results and grades.

---

## 📊 UML Class Diagram

You can generate the **Class Diagram** using **PlantUML**.

### Steps:
1. Copy the `diagram.puml` file (included in the repo).
2. Go to [PlantText](https://www.planttext.com/) or use **VSCode + PlantUML extension**.
3. Paste the code and click **Generate**.
4. You’ll get the full UML diagram for the system.

Example UML snippet:
```plantuml
@startuml
class Answer {
  - AnswerId : int
  - AnswerText : string
  + ToString() : string
  + Clone() : object
}
abstract class Question {
  - Header : string
  - Body   : string
  - Mark   : int
  - AnswerList : Answer[]
  + DisplayQuestion() : void
  + ToString() : string
}
Question <|-- MCQQuestion
Question <|-- TFQuestion
Exam <|-- PracticalExam
Exam <|-- FinalExam
Subject --> Exam
Question --> Answer
@enduml

