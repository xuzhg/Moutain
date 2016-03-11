using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Wrox
{
    public class Document
    {
        public string Title { get; private set; }
        public string Content { get; private set; }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }
    }

    public class DocumentManager
    {
        private readonly Queue<Document> documentQueue = new Queue<Document>();

        public void AddDocument(Document doc)
        {
            lock (this)
            {
                documentQueue.Enqueue(doc);
            }
        }

        public Document GetDocument()
        {
            Document doc = null;
            lock (this)
            {
                doc = documentQueue.Dequeue();
            }

            return doc;
        }

        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }
    }

    public class ProcessDocuments
    {
        public static void Start(DocumentManager dm)
        {
            Task.Factory.StartNew(new ProcessDocuments(dm).Run);
        }

        protected ProcessDocuments(DocumentManager dm)
        {
            if (dm == null)
                throw new ArgumentNullException("dm");
            documentManager = dm;
        }

        private DocumentManager documentManager;

        protected void Run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvailable)
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine("Processing document {0}", doc.Title);
                }
                Thread.Sleep(new Random().Next(20));
            }
        }
    }

    class Program
    {
        static void Main()
        {
            var dm = new DocumentManager();

            ProcessDocuments.Start(dm);

            // Create documents and add them to the documentManager
            for (int i = 0; i < 1000; i++)
            {
                var doc = new Document("Doc " + i, "content");
                dm.AddDocument(doc);

                Console.WriteLine("Added document {0}", doc.Title);
                Thread.Sleep(new Random().Next(20));
            }
        }
    }
}