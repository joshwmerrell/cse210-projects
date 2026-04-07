This is my final project program!
What it does is it searched through the entirety of the Chruch of Jesus Christ of Latter-day Saints' Standard Works for what you want.
Currently, it is able to search up a volume, book, or single verse within these works.

When you search up a volume of scripture with the command "volume@", it looks up the volume, gives you its full name and a list of all the books contained within it.
When you search up a book of scripture with the command "book@", it looks up the book and it lists all the chapters there are with how many verses there are within it.
Finally, when you search up a singular verse of scripture with the "verse@" command, it gives you the title of the verse and the text of it.

Currently, how it is set up, some of the verses within the Doctrine and Covenants and the Pearl of Greath Price are not full because they are versed that uses quotation marks within their verses.
This will be fixed at a later date and does not currently affect any of the functionality of the program.
The program was also designed to search up multiple verses at once, and you'd be able to vew whole chapters of sscripture, but it currently doesn't have those functions yet.

Now, pertaining to the requirements of the design and submission, here are the descriptions of each class and what they do most importantly:
1. Program.cs
    The program class is the most used and reference class in a program because it is the code that immidiately interacts with the user and most often as well.
    The program's functions do the following:
        1. Wipes the terminal of all text.
        2. Takes and organizes the scriptures from a csv file I found at this URL, https://scriptures.nephi.org/, into a list that it may be easily stored and be readily available to organize into Scripture classes.
        3. Introduces the user with a short welcome and introduction.
        4. Gives the user a list of commands and a very breif and concise visual of it.
        5. Allows the user to either search or end the program.
2. SearchScriptures.cs
    The search scriptures class is the class that A. organizes the scriptures csv list into their classes, and B. searches through them in an organized fashion.
    I decided to put most of what happens with organizing and searching in the search scriptures class because of just how much goes on in it.
    Here are this classes main and primary functions:
        1. Organize a csv file made-list into volumes of scripture.
        2. Determine based on the command used what to search for and how deep to search for it.
        3. Used both the determined depth and the string the user entered to search for what the user is looking for.
3. Scripture.cs
    This is the abstract class that the following classes and based on: Volume, Book, Chapter, and Verse.
    Being that one is able to search for different scopes and things in scripture, I designed this class to be able to build lists of itself within it.
    These are the main functions of thiss class:
        1. Assign itself a name and a number for both reference and recognizability.
        2. Retrieve the asssigned identifiers and search for something based on search depth and search inquiry.
4. Volume.cs
    This is the scripture-based class that holds books, chapters, and verses within itself like a russian nesting-doll. These are its main functions:
        1. Assign itself a name and a number for both reference and recognizability.
        2. Asssign and organize a list of book classes within it.
        3. When told to search, based on search depth, determine and execute whether to search for a volume, or to pass the search down into its Book classes.
5. Book.cs
    This is the scripture-based class that is found within a volume, and holds chapters and verses within itself like a russian nesting-doll.
    These are its main functions:
        1. Assign itself a name and a number for both reference and recognizability.
        2. Asssign and organize a list of chapter classes within it.
        3. When told to search, based on search depth, determine and execute whether to search for a book, or to pass the search down into its chapter classes.
6. Chapter.cs
    This is the scripture-based class that is found within a book and volume like a russian nesting-doll, and holds verses within itself.
    These are its main functions:
        1. Assign itself a number for reference.
        2. Asssign and organize a list of verse classes within it.
        3. **Disclaimer: It currently cannot search for a chapter yet** When told to search, based on search depth, determine and execute whether to search for a chapter, or to pass the search down into its verses classes.
7. Verse.cs
    This is the smallest scripture-based class. It holds its own verse in two ways:
    A. as a whole string. This is what is used when grabbing versed to display to the user.
    B. This is also split up into a list or Word objects.
    The verse class is meant to do all of its parents' classes do, but it also has two unique names.
    These help the user search for the verse better.
8. Word.cs
    The smallest part of this russian nesting-doll.
    There ends up being an innumerous amount of Word objects being created and established.
    The word object is unique.
    Not only are you able to assign and grab a word from each object, but it stores it in integer index positions that is based off of an alphabet built into each Word object.