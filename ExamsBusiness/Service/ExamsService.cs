using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Repositories.Exams;
using ExamsBusiness.Models;

namespace ExamsBusiness.Service
{
    class ExamsService : IExamsService
    {
        private readonly IExamsRepository _examsRepository;
        private readonly IMapper _mapper;

        public ExamsService(IExamsRepository examsRepository, IMapper mapper)
        {
            _examsRepository = examsRepository;
            _mapper = mapper;
        }


        public async Task<List<ExamModel>> GetExamsList()
        {
            try
            {

                List<ExamModel> result = new List<ExamModel>();
                var exams = await _examsRepository.GetExamsList();

                if (exams != null && exams.Count > 0)
                {
                    foreach (var item in exams)
                    {
                        var exam = _mapper.Map<ExamModel>(item);
                        result.Add(exam);
                    }
                }
                return result;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<ExamDetailsModel> GetExamDetails(int ExamId)
        {
            try
            {
                var result = new ExamDetailsModel();
                var examDetails = await _examsRepository.GetExamDetails(ExamId);
                if (examDetails != null)
                {
                    result.ExamDetails = _mapper.Map<ExamModel>(examDetails);
                    if (result.ExamStudents != null && result.ExamStudents.Count > 0)
                    {
                        foreach (var student in result.ExamStudents)
                        {
                            result.ExamStudents.Add(_mapper.Map<StudentDetails>(student));
                        }
                    }
                     
            
                }
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }



    
}
}
