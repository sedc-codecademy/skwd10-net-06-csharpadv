namespace AdvancedLinq
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            /****************************
             * Find student with name Bob
             ****************************/

            // SQL Like
            IEnumerable<Student> findBobsSql = 
                from student in SEDC.Students
                where student.FirstName == "Bob"
                select student;
            
            findBobsSql.Print(nameof(findBobsSql));

            // Lambda Expression
            IEnumerable<Student> findBobsLambda =
                SEDC.Students
                    .Where(student => student.FirstName == "Bob");

            findBobsLambda.Print(nameof(findBobsLambda));



            /******* Select method *********
             * customize your query output *
             *******************************/

            // SQL Like
            // return only first name
            IEnumerable<string> firstNamesSql = 
                from student in SEDC.Students
                select student.FirstName;

            firstNamesSql.Print(nameof(firstNamesSql));

            // return concatenated first name and last name
            IEnumerable<string> studentFullNamesSql = 
                from student in SEDC.Students
                select $"{student.FirstName} {student.LastName}";

            studentFullNamesSql.Print(nameof(studentFullNamesSql));

            // Lambda Expression
            // return only first name
            IEnumerable<string> firstNamesLambda =
                SEDC.Students
                    .Select(student => student.FirstName);

            firstNamesLambda.Print(nameof(firstNamesLambda));
            
            // return concatenated first name and last name
            IEnumerable<string> studentFullNamesLambda =
                SEDC.Students
                    .Select(student => $"{student.FirstName} {student.LastName}");

            studentFullNamesLambda.Print(nameof(studentFullNamesLambda));



            /************************** First method (and variants) ************************
             * get the first element that matches filter (filter can be empty = no filter) *
             *******************************************************************************/

            // get first student in collection - will fail if no student found
            Student firstStudent = SEDC.Students.First();
            // get first student in collection - if not found, return null
            Student firstOrDefaultStudent = SEDC.Students.FirstOrDefault();
            // get first student in collection with first name == Bob - will fail if no student found
            Student firstStudentNamedBob = SEDC.Students.First(student => student.FirstName == "Bob");
            // get first student in collection with first name == Bob - if not found, return null
            Student firstOrDefaultStudentNamedBob = SEDC.Students.FirstOrDefault(student => student.FirstName == "Bob");

            Console.WriteLine($"firstStudent: {firstStudent}");
            Console.WriteLine($"firstOrDefaultStudent: {firstOrDefaultStudent}");
            Console.WriteLine($"firstStudentNamedBob: {firstStudentNamedBob}");
            Console.WriteLine($"firstOrDefaultStudentNamedBob: {firstOrDefaultStudentNamedBob}");

            // empty Student collection to illustrate some edge scenarios
            IEnumerable<Student> emptyStudentCollection = Enumerable.Empty<Student>();

            // this will fail because we are trying to get the first element from an empty collection
            // Student invalidFirstStudent = emptyStudentCollection.First();

            // this will return null because no first element exists in an empty collection
            // Student invalidFirstOrDefaultStudent = emptyStudentCollection.FirstOrDefault();

            // this will fail because we are searching for the first student with first name that does not exist
            // Student invalidFirstStudentNamedPero = SEDC.Students.First(student => student.FirstName == "Pero");

            // this will return null because we are searching for the first student with first name that does not exist
            // Student invalidFirstOrDefaultStudentNamedPero = SEDC.Students.FirstOrDefault(student => student.FirstName == "Bob");



            /*********************** Last method (and variants) ***************************
             * get the last element that matches filter (filter can be empty = no filter) *
             ******************************************************************************/

            // get last student in collection - will fail if no student found
            Student lastStudent = SEDC.Students.Last();
            // get last student in collection - if not found, return null
            Student lastOrDefaultStudent = SEDC.Students.LastOrDefault();
            // get last student in collection with first name == Bob - will fail if no student found
            Student lastStudentNamedBob = SEDC.Students.Last(student => student.FirstName == "Bob");
            // get last student in collection with first name == Bob - if not found, return null
            Student lastOrDefaultStudentNamedBob = SEDC.Students.LastOrDefault(student => student.FirstName == "Bob");

            Console.WriteLine($"lastStudent: {lastStudent}");
            Console.WriteLine($"lastOrDefaultStudent: {lastOrDefaultStudent}");
            Console.WriteLine($"lastStudentNamedBob: {lastStudentNamedBob}");
            Console.WriteLine($"lastOrDefaultStudentNamedBob: {lastOrDefaultStudentNamedBob}");

            // this will fail because we are trying to get the last element from an empty collection
            // Student invalidLastStudent = emptyStudentCollection.Last();

            // this will return null because no last element exists in an empty collection
            // Student invalidLastOrDefaultStudent = emptyStudentCollection.LastOrDefault();

            // this will fail because we are searching for the last student with first name that does not exist
            // Student invalidLastStudentNamedPero = SEDC.Students.Last(student => student.FirstName == "Pero");

            // this will return null because we are searching for the last student with first name that does not exist
            // Student invalidLastOrDefaultStudentNamedPero = SEDC.Students.LastOrDefault(student => student.FirstName == "Pero");



            /************************* Single method (and variants) **************************
             * get the SINGLE element that matches filter (filter can be empty = no filter)  *
             *       if there's more than one element that matches the criteria - fail       *
             *********************************************************************************/

            // this will fail because there's more than one element in the collection, and we are not filtering the results
            // Student singleStudent = SEDC.Students.Single();

            // this will fail because there's more than one element in the collection, and we are not filtering the results
            // Student singleOrDefaultStudent = SEDC.Students.SingleOrDefault();

            // this will return the single student with Id == 30
            Student singleStudentWithId30 = SEDC.Students.Single(student => student.Id == 30);
            
            // this will return null because we don't have a student with Id == 99
            Student singleOrDefaultStudentWithId99 = SEDC.Students.SingleOrDefault(student => student.Id == 99);

            Console.WriteLine($"singleStudentWithId30: {singleStudentWithId30}");
            Console.WriteLine($"singleOrDefaultStudentWithId99: {singleOrDefaultStudentWithId99}");

            // these will not fail and return null
            Student singleOrDefaultStudentOverEmptyCollection = emptyStudentCollection.SingleOrDefault();
            Student singleOrDefaultStudentOverEmptyCollectionWithId99 = emptyStudentCollection.SingleOrDefault(student => student.Id == 99);

            Console.WriteLine($"singleOrDefaultStudentOverEmptyCollection: {singleOrDefaultStudentOverEmptyCollection}");
            Console.WriteLine($"singleOrDefaultStudentOverEmptyCollectionWithId99: {singleOrDefaultStudentOverEmptyCollectionWithId99}");

            
            
            /*********************************** SelectMany method *******************************************
             * flatten a multi-dimensional collection (collection of collections) into a one-dimensional one *
             *************************************************************************************************/

            // The issue with Select when working with Collection properties
            // We have a list of lists and that is hard to work with
            IEnumerable<List<Subject>> partTimeSubjectsSelect = SEDC.Students
                .Where(student => student.IsPartTime)
                .Select(student => student.Subjects);
            
            partTimeSubjectsSelect.PrintNested<List<Subject>, Subject>(nameof(partTimeSubjectsSelect));

            // Merging the lists together
            // if there are subjects that are attended by multiple students, this will produce duplicates
            IEnumerable<Subject> partTimeSubjectsMany = SEDC.Students
                .Where(student => student.IsPartTime)
                .SelectMany(student => student.Subjects);

            partTimeSubjectsMany.Print(nameof(partTimeSubjectsMany));



            /******************** Distinct method ************************
             * removes duplicates (if any) for existing query/collection *
             *************************************************************/

            IEnumerable<Subject> distinctSubjects = partTimeSubjectsMany.Distinct();

            distinctSubjects.Print(nameof(distinctSubjects));



            /**************************** Any method *************************************
             *    checks if there are any elements matching the provided condition       *
             *  condition can be omitted, then it check if collection has any elements   *
             * returns true or false depending on whether any elements satisfy condition *
             *****************************************************************************/

            bool bobExists = SEDC.Students
                .Any(student => student.FirstName == "Bob");

            // prints true
            Console.WriteLine($"bobExists: {bobExists}");

            bool peroExists = SEDC.Students
                .Any(student => student.FirstName == "Pero");

            // prints false
            Console.WriteLine($"peroExists: {peroExists}");



            /**************************** All method ******************************************
             *  checks if there ALL elements in query/collection match the provided condition *
             *                   condition/filter can NOT be omitted                          *
             *      returns true or false depending on whether ALL elements satisfy condition *
             **********************************************************************************/

            bool doAllStudentsHaveLongNames = SEDC.Students
                .All(student => student.FirstName.Length >= 3);

            // prints true
            Console.WriteLine($"doAllStudentsHaveLongNames: {doAllStudentsHaveLongNames}");

            bool areAllStudentsElderly = SEDC.Students
                .All(student => student.Age > 60);

            // prints false
            Console.WriteLine($"areAllStudentsElderly: {areAllStudentsElderly}");



            /*********************** Except method ******************************
             * produces set difference for sets/collection that might have some *
             *                      common elements                             *
             ********************************************************************/

            IEnumerable<Student> partTimeStudents = SEDC.Students.Where(x => x.IsPartTime);

            partTimeStudents.Print(nameof(partTimeStudents));

            // equivalent to SEDC.Students.Where(x => x.IsPartTime == false)
            IEnumerable<Student> exceptPartTimeStudents =
                SEDC.Students
                    .Except(partTimeStudents);

            exceptPartTimeStudents.Print(nameof(exceptPartTimeStudents));



            /************** OrderBy/OrderByDescending methods ************************
             * order/sort collection according to a certain property of the elements *
             *************************************************************************/

            // alphabetical sort by first name
            IEnumerable<Student> sortedStudentsByFirstName = SEDC.Students
                .OrderBy(x => x.FirstName);

            sortedStudentsByFirstName.Print(nameof(sortedStudentsByFirstName));

            // alphabetical sort by first name, descending
            IEnumerable<Student> sortedStudentsByFirstNameDesc = SEDC.Students
                .OrderByDescending(x => x.FirstName);

            sortedStudentsByFirstNameDesc.Print(nameof(sortedStudentsByFirstNameDesc));

            IEnumerable<Student> sortedStudentsMultipleProperties = SEDC.Students
                // first sort by first name
                .OrderBy(student => student.FirstName)
                // if there are students with same first name, sort them by age
                .ThenBy(student => student.Age)
                // and additionally, if there are students with same first name and age,
                // sort by id
                .ThenBy(student => student.Id);

            sortedStudentsMultipleProperties.Print(nameof(sortedStudentsMultipleProperties));



            /**************** Complex (nested) query **********************
             * combine results of different queries to get needed results *
             **************************************************************/

            // SQL Like
            // get all the part-time students that have programming subjects assigned
            IEnumerable<Student> studentsWithProgrammingSubjectsSqlQuery = from student in SEDC.Students
                where student.IsPartTime
                where (
                    // a sub-query to check if there are any
                    // subjects of type == Academy.Programming
                    // assigned to current student
                    from subject in student.Subjects
                    where subject.Type == Academy.Programming
                    select subject
                ).Any()
                select student;

            studentsWithProgrammingSubjectsSqlQuery.Print(nameof(studentsWithProgrammingSubjectsSqlQuery));

            // Lambda Expression
            // get all the part-time students that have programming subjects assigned
            IEnumerable<Student> studentsWithProgrammingSubjectsLambdaQuery = SEDC.Students
                .Where(student => student.IsPartTime)
                .Where(student => student.Subjects.Any(subject => subject.Type == Academy.Programming));

            studentsWithProgrammingSubjectsLambdaQuery.Print(nameof(studentsWithProgrammingSubjectsLambdaQuery));
        }
    }

    public static class CustomLinq
    {
        public static IEnumerable<Student> WhereCustom(this IEnumerable<Student> collection, Func<Student, bool> filter)
        {
            var result = new List<Student>();

            foreach (var student in collection)
            {
                var filterResult = filter(student);

                if (filterResult == true)
                {
                    result.Add(student);
                }
            }

            return result;
        }
    }

    public static class PrintExtensions
    {
        public static void Print<T>(this IEnumerable<T> collection, string tableHeader = null)
        {
            Console.WriteLine();
            
            if (!string.IsNullOrWhiteSpace(tableHeader))
            {
                Console.WriteLine(tableHeader);
                Console.WriteLine(new string('~', tableHeader.Length));
            }

            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }

        public static void PrintNested<TColl, TElem>(this IEnumerable<TColl> nestedCollection, string tableHeader = null) where TColl: IEnumerable<TElem>
        {
            Console.WriteLine();
            
            if (!string.IsNullOrWhiteSpace(tableHeader))
            {
                Console.WriteLine(tableHeader);
                Console.WriteLine(new string('~', tableHeader.Length));
                Console.WriteLine(new string('~', tableHeader.Length));
            }

            for (int i = 0; i < nestedCollection.Count(); i++)
            {
                nestedCollection.ElementAt(i).Print($"{tableHeader}[{i}]");
            }

            Console.WriteLine();
        }
    }
}
