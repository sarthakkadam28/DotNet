using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssessmentLib.Entities
{
    public class Assessment
    {
        public int Id { get; set; }
        public string TestName {  get; set; }
        public int SubjectId {  get; set; }
        public TimeOnly Duration { get; set; }


    }
}
