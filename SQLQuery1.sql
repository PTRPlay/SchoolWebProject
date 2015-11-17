SELECT dbo.Users.Id, dbo.Schedules.DayOfTheWeek, dbo.Schedules.OrderNumber, dbo.Schedules.SubjectId,dbo.Subjects.Name
 FROM dbo.Users, dbo.Schedules, dbo.Subjects
WHERE dbo.Users.GroupId = dbo.Schedules.GroupId AND dbo.Schedules.SubjectId=dbo.Subjects.Id

