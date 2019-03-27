--DBCC CHECKIDENT (contentList, RESEED, 0)
--DBCC CHECKIDENT (Content_SectionList, RESEED, 0)



select * from ContentItemList
select * from ContentList order by ContentListID
--select * from Content_SectionList
select * from SectionList

SELECT FileList.FileName 
FROM File_SectionList INNER JOIN FileList 
ON File_SectionList.FileListID = FileList.FileListID INNER JOIN SectionList 
ON SectionList.SectionListID = File_SectionList.SectionListID 
WHERE SectionList.SectionListID = 23 AND FileList.RecordState = 1

SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE FileList.RecordState = 1 AND File_SectionList.SectionListID = 4



SELECT ContentList.ContentDesc FROM ContentList INNER JOIN ContentItemList ON ContentList.ContentItemListID = ContentItemList.ContentItemListID INNER JOIN SectionList ON ContentList.SectionListID = SectionList.SectionListID WHERE ContentItemList.ContentItemListID = 2 AND ContentList.SectionListID = 3;
--delete from ContentList
--delete from Content_SectionList
SELECT ContentDesc FROM ContentList where ContentItemListID = 1 and SectionListID = 2

SELECT FileList.FileName FROM File_SectionList INNER JOIN FileList ON File_SectionList.FileListID = FileList.FileListID WHERE File_SectionList.SectionListID = 4 AND FileList.RecordState = 1


SELECT ContentList.ContentDesc FROM ContentList INNER JOIN ContentItemList ON ContentList.ContentItemListID = ContentItemList.ContentItemListID INNER JOIN SectionList ON ContentList.SectionListID = SectionList.SectionListID WHERE ContentItemList.ContentItemListID = 1 AND ContentList.SectionListID = 2

Update ContentList set ContentDesc = 'test' where ContentItemListID = 3  
--insert into Content_SectionList values(3, 2)
--insert into ContentList values(1, 'Australian Rueston Water')

--insert into ContentList values(2, 'We grow water 100% from fruit & vegetables')

--insert into ContentList values(3, 'At Rueston we found a way to harvest the naturally occurring water from Australian fruits & vegetables at the same time as juice concentrate is made. Utilising every available drop of water contained in the fruits & vegetables, we''ve proudly created a new sustainable source ¨C Botanical water! It''s an award winning Australian invention, grown and owned in Australia! ')



