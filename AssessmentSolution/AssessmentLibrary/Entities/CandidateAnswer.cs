namespace Transflower.TFLAssessment.Entities;

public class CandidateAnswer
{
    public int Id { get; set; }
    public int CandidateId { get; set; }
    public int TestQuestionId { get; set; }
    public string  AnswerKey { get; set; }
      
}