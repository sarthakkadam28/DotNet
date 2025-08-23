using AssessmentSolution.Entities;
using AssessmentSolution.Repositories;
using AssessmentSolution.services;


builder.Services.AddScoped<ISubjectRepository, SubjectRepository>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
