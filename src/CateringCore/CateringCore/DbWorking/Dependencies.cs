using System.Collections.Generic;
using System.Linq;
using CateringCore.Model;

namespace Catering.DbWorking;

public static class Dependencies
{
	private static ApplicationContext Context => DataBaseConnection.Instance.CurrentContext;

	// private static IEnumerable<Lesson> Lessons => Context.Lessons.AsEnumerable();

	public static List<string> For<T>(Table table)
		=> table.Visit
		(

			// forStudent: ForStudent
		);

	// private static List<string> ForStudent(Student student)
	// {
	// 	var ourIndividualCourses = IndividualCourses.Where((ic) => ic.Student == student).ToList();
	// 	var individualCourses = ourIndividualCourses.Select(Format).ToList();
	// 	var groupCourses = GroupCourses.Where((ic) => ic.Student == student).Select(Format).ToList();
	// 	var schedules = ourIndividualCourses.SelectMany(For);
	//
	// 	return individualCourses.Concat(groupCourses).Concat(schedules).ToList();
	// }

	// private static string Format(Lesson lesson) => FromTable(lesson.ToString(), "Занятия");
}