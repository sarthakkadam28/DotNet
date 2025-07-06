using System;
using System.IO;
using System.RUNTIME.Serialization.Formatters.Binary;
using System.Text.Json;

namespace app
{
    public class Question
    {
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Optiona
        {
            get { return optiona; }
            set { optiona = value; }
        }

        public string Optionb
        {
            get { return optionb; }
            set { optionb = value; }
        }

        public string Optionc
        {
            get { return optionc; }
            set { optionc = value; }
        }

        public string Optiond
        {
            get { return optiond; }
            set { optiond = value; }
        }
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
        public string EvaluationCriteria
        {
            get { return evalutioncriteria; }
            set { evalutioncriteria = value; }
        }
    }

    public class DbManger
    {
        private readonly string fileName;
        private readonly List<Question> questions;

        public DbManger(string fileName, List<Question> questions)
        {
            fileName = fileName;
            questions = questions;
        }
        public void SaveData()
        {
            Question question = new Question { List < Question > questions, fileName };
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                formatter.Serialize(fs, questions);
            }

            Console.WriteLine("Object serialized successfully.");

        }
        public class FileIo
        {
            public void Serialize(List<Question> questions, string fileName)
            {
                var options = new JsonSerializerOptions { IncludeFields = true };
                var questionsJson = JsonSerializer.Serialize(questions, options);
                File.WriteAllText(fileName, questionsJson);
            }

            public List<Question> DeSerialize(string fileName)
            {
                string jsonString = File.ReadAllText(fileName);
                List<Question> questions = JsonSerializer.Deserialize<List<Question>>(jsonString);

                foreach (Question q in questions)
                {
                    Console.WriteLine($"{q.Id} : {q.Text}");
                }

                return questions;
            }
        }
    }
}



    