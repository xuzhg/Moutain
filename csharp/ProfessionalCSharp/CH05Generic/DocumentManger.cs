using System;
using System.Collections.Generic;

namespace Wrox
{
	public class DocumentManager<T> where T : IDocument
	{
		private readonly Queue<T> documentQueue = new Queue<T>();
		
		public void AddDocument(T doc)
		{
			lock(this)
			{
				documentQueue.Enqueue(doc);
			}
		}
		
		public void DisplayAllDocuments()
		{
			foreach(T doc in documentQueue)
			{
				Console.WriteLine(doc.Title);
			}
		}
		
		public bool IsDocumentAvailable
		{
			get { return documentQueue.Count > 0; }
		}
		
		public T GetDocument()
		{
			T doc = default(T);
			lock(this)
			{
				doc = documentQueue.Dequeue();
			}
			return doc;
		}
	}
	
	public interface IDocument
	{
		string Title {get;set;}
		string Content {get;set;}
	}
	
	public class Document : IDocument
	{
		public Document()
		{
			
		}
		
		public Document(string title, string content)
		{
			this.Title = title;
			this.Content = content;
		}
		
		public string Title {get;set;}
		public string Content {get;set;}
	}
	
	public class Program
	{
		public static void Main()
		{
			var dm = new DocumentManager<Document>();
			dm.AddDocument(new Document("Title A", "Sample A"));
			dm.AddDocument(new Document("Title B", "Sample B"));
			
			dm.DisplayAllDocuments();
			
			if (dm.IsDocumentAvailable)
			{
				Document d = dm.GetDocument();
				Console.WriteLine(d.Content);
			}
			
			dm.DisplayAllDocuments();
		}
	}
}