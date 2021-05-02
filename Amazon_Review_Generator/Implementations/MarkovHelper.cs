using Amazon_Review_Generator.Contracts;
using Amazon_Review_Generator.Models;
using Markov;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Amazon_Review_Generator.Implementations
{
    public class MarkovHelper : IMarkovHelper
    {
        private readonly List<Review> reviewsList = new List<Review>();
        private MarkovChain<string> _chain;

        /// <inheritdoc/>
        public MarkovChain<string> Chain
        {
            get
            {
                if (_chain == null)
                {
                    _chain = new MarkovChain<string>(1);                    
                }

                return _chain;
            }

            set { _chain = value;  }
        }

        /// <inheritdoc/>
        public List<Review> Ingest(string[] sampleData = null)
        {
            List<string> fileContents = sampleData == null ? new List<string>() : sampleData.ToList();

            if (sampleData == null)
            {
                foreach (string fileName in Directory.EnumerateFiles(Path.Combine(Environment.CurrentDirectory, "Sample Data")))
                {
                    fileContents.AddRange(File.ReadAllLinesAsync(fileName).Result.ToList());
                }
            }            

            foreach(string line in fileContents)
            {
                reviewsList.Add(JsonConvert.DeserializeObject<Review>(line));
            }

            return reviewsList;
        }

        /// <inheritdoc/>
        public MarkovChain<string> Train()
        {
            MarkovChain<string> Chain = new MarkovChain<string>(1);
            foreach (Review review in reviewsList)
            {
                // This process ensures that the formatting is retained so that we can deserialize and display a formatted JSON object.
                Chain.Add(new string[] { "{", $"\"reviewerID\":", $"\"{review.reviewerID}\",",
                                         $"\"asin\":", $"\"{review.asin}\",",
                                         $"\"reviewerName\":", $"\"{review.reviewerName ?? "Not Available"}\",",
                                         $"\"helpful\":", $"[{review.helpful[0]}, {review.helpful[1]}],",
                                         $"\"reviewText\":", $"\"{review.reviewText}\",",
                                         $"\"overall\":", $"\"{review.overall}\",",
                                         $"\"summary\":", $"\"{review.summary}\",",
                                         $"\"unixReviewTime\":", $"\"{review.unixReviewTime}\",",
                                         $"\"reviewTime\":", $"\"{review.reviewTime}\"", "}"}, 1);
            }

            return Chain;
        }
    }
}
