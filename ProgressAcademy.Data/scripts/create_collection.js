const mentorsData = [
    { 
        "_id": 1, 
        first_name: 'Elizabeth',
        last_name:' Boyd', 
        email: 'Elizabeth.Boyd@pg.com'},
    { 
        "_id": 2, 
        first_name: 'Steven', 
        last_name:' Taylor',
        email: 'Steven.Taylor@pg.com'
    }
];

const menteesData = [
    { 
        "_id" : 1, 
        first_name: 'Anthony', 
        last_name:' Strickland'},
    { 
        "_id" : 2, 
        first_name: 'Samantha', 
        last_name:' Miller'}
];

 const plansData = [
     {
         "_id": 1, 
         Title: "Middle .Net Developer", 
         CurrentProgress: 30, 
         StartDate: "2023-01-01",
         EndDate: "2023-02-01",
         Description: "",
         Task: "Math task",
         Grade: "Middle",
         Lessons: [
             {
             LessonId: 1,
             Title: "Data Structures"
         }]
     }
 ];
 
const lessonsData = [
    {
        "_id": 1,
        Topic: "Data Structures",
        Themes: [
            {
                ThemeId: 1,
                Title: "Array"
            },
            {
                ThemeId: 2,
                Title: "Linked List"
            },
            {
                ThemeId: 3,
                Title: "Tree"
            },
            {
                ThemeId: 4,
                Title: "Graph"
            },
            {
                ThemeId: 5,
                Title: "Hash Table"
            }
        ],
        StartDate: ISODate("2023-01-01"),
        EndDate: ISODate("2023-01-01"),
        CurrentProgress: 15,
        MeetingNote: ""
    }]

const themesData =[
    { 
        "_id": 1,
        Title: "Array",
        Content: "Introduction to arrays and basic operations",
        Goal: "",
        Practice:"",
        MaxScore:100
    },
    { 
        "_id": 2,
        Title: "Linked List",
        Content: "Understanding linked list data structure",
        Goal: "",
        Practice:"",
        MaxScore:100
    },
    { 
        "_id": 3,
        Title: "Tree",
        Content: "Introduction to tree data structure",
        Goal: "",
        Practice:"",
        MaxScore:100
    },
    { 
        "_id": 4,
        Title: "Graph",
        Content: "Basics of graph data structure",
        Goal: "",
        Practice:"",
        MaxScore:100
    },
    { 
        "_id": 5,
        Title: "Hash Table",
        Content: "Understanding hash table data structure" ,
        Goal: "",
        Practice:"",
        MaxScore:100
    }
    ]

db.createCollection("mentors");
db.createCollection("mentees");
db.createCollection("plans");
db.createCollection("lessons");
db.createCollection("themes");

db.mentors.insert(mentorsData);
db.mentees.insert(menteesData);
db.plans.insert(plansData);
db.lessons.insert(lessonsData);
db.themes.insert(themesData);



