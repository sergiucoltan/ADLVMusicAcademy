# ADLVMusicAcademy
Web app for online music school
Ad Libitum Voices Music Academy
The goal is to build a functional website with a database, for a music school academy. The app enables management of student enrollments, schedules, sending mass notifications to students and their parents, share lesson plans, sheet music, online tutorials. The app will contain a front page with informations, alongside with a news and events section, teacher profiles, available courses, helpful tools, and a career page for other teacher to apply CV.
Different roles with separate permissions:

1.	Guests : 

- can view the courses. 
- can view the teachers.
-  can see newsfeed. 
- can create an account. confirmation email will be received upon account creation. Possible integration with SendGrid.

2.	Student 

- can buy and activate a subscription to classes.
- can choose a teacher and enroll to individual courses.
- can create posts
- can view the schedule.
- can download courses, music sheets assigned for him, scores.
- can use tools : metronome, tuner, virtual keyboard.

3.	Teacher

- can schedule lessons with the students enrolled in his classes
- upload resources to each lesson
- can cancel or postpone course 

4.	Manager
- can manage subscriptions
- can delete accounts, posts, add, delete courses, change schedule
- can create profiles for teachers, edit areas of the website, post jobs on the careers page.

5.	Admin
- all permissions
- Can assign roles to anyone


Entities 

Student: 
- Id (guid)
- Username – will be auto generated. Username is a combination of First Name + first letter of last - --name.
- Password (string)
- Email (string)
- Parent / Guardian Email (if under 18)
- First Name (string)
- Last Name (string)
- DoB (DateTime)
- Address
- Mobile


Employee:
- Id (guid)
- Username – will be auto generated. Username is a combination of First Name + first letter of last - --name.
- Password (string)
- Email (string)
- First Name (string)
- Last Name (string)
- DoB (DateTime)
- Address
- Mobile
- Roles
- Courses


Course:

- name
- description

Lesson: 

- Date
- Resources
- Teacher
- Student(s)
- Status

The aproach is database first
