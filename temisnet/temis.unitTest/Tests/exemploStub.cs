/*
namespace temis.unitTest.Tests
{
    public class GradesServiceTest {
        private Student student;
        private Gradebook gradebook;

        @Before
        public void setUp() throws Exception {
            gradebook = mock(Gradebook.class);
            student = new Student();
        }

        @Test
        public void calculates_grades_average_for_student() {
            when(gradebook.gradesFor(student)).thenReturn(grades(8, 6, 10)); //stubbing gradebook
            double averageGrades = new GradesService(gradebook).averageGrades(student);
            assertThat(averageGrades).isEqualTo(8.0);
        }
    }
}
*/