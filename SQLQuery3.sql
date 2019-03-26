select * from QuestionList 

select * from storyList

--insert into StoryList(StoryOrder, StoryContent) values(3, '100% Australian owned and made, Rueston is a super premium brand encased in a stylish blue glass bottle and exclusively available in Australia''s finest venues. Top chefs, wine connoisseurs and foodies all love Rueston for its unique source and exquisite flavour.')

Select StoryContent From StoryList Where RecordState = 1 And StoryOrder = 1

SELECT        FileList.FileName
FROM            File_SectionList INNER JOIN
                         FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN
                         SectionList ON File_SectionList.SectionListID = SectionList.SectionListID
WHERE FileList.RecordState = 1 AND SectionList.SectionListID = 23


SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 15 AND FileList.RecordState = 1


SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON SectionList.SectionListID = File_SectionList.SectionListID WHERE SectionList.SectionListID = 15 AND FileList.RecordState = 1

update ContentList Set ContentDesc = 'Absolute Purification1' Where ContentItemListID = 1 and SectionListID = 15

SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE FileList.RecordState = 1 AND File_SectionList.SectionListID = 15



SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList ON File_SectionList.SectionListID = SectionList.SectionListID WHERE  FileList.RecordState = 1 AND SectionList.SectionListID = 22

