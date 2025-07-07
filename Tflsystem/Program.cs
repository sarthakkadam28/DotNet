// See https://aka.ms/new-console-template for more information
using Assesment.Entities;
using app;
using Persistance;

QuestionBank questionbank = new QuestionBank();

Question question1 = new Question();
question1.Title = "What is your name ?";
question1.Optiona = "Ravi";
question1.Optionb = "Sarthak";
question1.Optionc = "Om";
question1.Optiond = "Sanika";
question1.Answer = "A";
question1.EvaluationCriteria = "4";
// question 1 madhala jo kahi data asel to questionbank madhe add karto
questionbank.InsertQuestion(question1);


Question q2 = new Question();
q2.Title = "What is your country name ?";
q2.Optiona = "Pakistan";
q2.Optionb = "USA";
q2.Optionc = "India";
q2.Optiond = "Burma";
q2.Answer = "C";
q2.EvaluationCriteria = "4";

questionbank.InsertQuestion(q2);

Question q3 = new Question();
q3.Title = "what is your favourite game ?";
q3.Optiona = "criket";
q3.Optionb = "hockey";
q3.Optionc = "vollyball";
q3.Optiond = "basketball";
q3.Answer = "c";
q3.EvaluationCriteria = "5";

Question qupdated = new Question();
qupdated.Title = "what is your favourite game ?";
qupdated.Optiona = "football";
qupdated.Optionb = "temmos";
qupdated.Optionc = "vollyball";
qupdated.Optiond = "basketball";
qupdated.Answer = "c";
qupdated.EvaluationCriteria = "5";

questionbank.UpdateQuestion("what is your favourite game ?", qupdated);

questionbank.ShowQuestion();

JsonFileManager mg = new JsonFileManager();
string fileName = "questions.json";
// jsonfilemanager cha object gheun serialize chi method call keli ahe ani tymaddhe 
// jo kahi list of questions data asel to questonbank madhe add hoil
mg.Serialize( questionbank.questions, fileName);

List<Question> allRetriveQuestions = mg.DeSerialize(fileName);

foreach (Question qt in allRetriveQuestions)
{
    qt.Display();
}

Uimanger u = new Uimanger();
u.showMenu();
