using Amazon_Review_Generator.Models;
using Markov;
using System.Collections.Generic;

namespace Amazon_Review_Generator.Contracts
{
    public interface IMarkovHelper
    {
        /// <summary>
        /// The markov chain object resulting from the Ingest and Train methods.
        /// </summary>
        MarkovChain<string> Chain { get; set; }

        /// <summary>
        /// Load sample data for training the Markov chain.
        /// <param name="sampleData">Optional sample data to supply.</param>/>
        /// </summary>
        List<Review> Ingest(string[] sampleData = null);

        /// <summary>
        /// Train the Markov Chain by loading the resulting Ingest data.
        /// </summary>
        MarkovChain<string> Train();
    }
}
