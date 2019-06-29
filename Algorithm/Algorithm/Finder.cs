using System.Collections.Generic;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _personList;
        private List<AgeDifferenceBetweenTwoPersonsTO> _ageDifferenceBetweenTwoPersonsTOList;

        public Finder(List<Person> personList)
        {
            _personList = personList;
            _ageDifferenceBetweenTwoPersonsTOList = CreateAgeDifferenceList();
        }

        public AgeDifferenceBetweenTwoPersonsTO FindAgeDifferenceBetweenTwoPersons(AgeDifferenceType ageDiffereceType)
        {

            if (_ageDifferenceBetweenTwoPersonsTOList.Count < 1)
                return new AgeDifferenceBetweenTwoPersonsTO();

            AgeDifferenceBetweenTwoPersonsTO result = _ageDifferenceBetweenTwoPersonsTOList[0];

            switch (ageDiffereceType)
            {
                case AgeDifferenceType.MinorDifference:
                    _ageDifferenceBetweenTwoPersonsTOList.ForEach(x =>
                    {
                        if (x.ageDifference < result.ageDifference)
                            result = x;
                    });
                    break;

                case AgeDifferenceType.HigherDifference:
                    _ageDifferenceBetweenTwoPersonsTOList.ForEach(ageDifference =>
                    {
                        if (ageDifference.ageDifference > result.ageDifference)
                            result = ageDifference;
                    });
                    break;
            }

            return result;
        }

        private List<AgeDifferenceBetweenTwoPersonsTO> CreateAgeDifferenceList()
        {
            var list = new List<AgeDifferenceBetweenTwoPersonsTO>();

            for (var i = 0; i < _personList.Count - 1; i++)
            {
                for (var j = i + 1; j < _personList.Count; j++)
                {
                    var r = new AgeDifferenceBetweenTwoPersonsTO();

                    bool isMinor = _personList[i].BirthDate < _personList[j].BirthDate;

                    r.person1 = isMinor ? _personList[i] : _personList[j];
                    r.person2 = isMinor ? _personList[j] : _personList[i];

                    r.ageDifference = r.person2.BirthDate - r.person1.BirthDate;
                    list.Add(r);
                }
            }

            return list;
        }
    }
}