using Amazon_Review_Generator.Controllers;
using Amazon_Review_Generator.Implementations;
using Amazon_Review_Generator.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Amazon_Review_Generator.Tests
{
    [TestClass]
    public class ReviewControllerTests
    {
        private string[] sampleData;

        [TestInitialize]
        public void TestInitialize()
        {
            sampleData = new string[] { "{\"reviewerID\": \"A2IBPI20UZIR0U\", \"asin\": \"1384719342\", \"reviewerName\": \"cassandra tu Yeah, well, that's just like, u...\", \"helpful\": [0, 0], \"reviewText\": \"Not much to write about here, but it does exactly what it's supposed to. filters out the pop sounds. now my recordings are much more crisp. it is one of the lowest prices pop filters on amazon so might as well buy it, they honestly work the same despite their pricing,\", \"overall\": 5.0, \"summary\": \"good\", \"unixReviewTime\": 1393545600, \"reviewTime\": \"02 28, 2014\"}",
                                        "{\"reviewerID\": \"A14VAT5EAX3D9S\", \"asin\": \"1384719342\", \"reviewerName\": \"Jake\", \"helpful\": [13, 14], \"reviewText\": \"The product does exactly as it should and is quite affordable.I did not realized it was double screened until it arrived, so it was even better than I had expected.As an added bonus, one of the screens carries a small hint of the smell of an old grape candy I used to buy, so for reminiscent's sake, I cannot stop putting the pop filter next to my nose and smelling it after recording. :DIf you needed a pop filter, this will work just as well as the expensive ones, and it may even come with a pleasing aroma like mine did!Buy this product! :]\", \"overall\": 5.0, \"summary\": \"Jake\", \"unixReviewTime\": 1363392000, \"reviewTime\": \"03 16, 2013\"}",
                                        "{\"reviewerID\": \"A195EZSQDW3E21\", \"asin\": \"1384719342\", \"reviewerName\": \"Rick Bennette Rick Bennette\", \"helpful\": [1, 1], \"reviewText\": \"The primary job of this device is to block the breath that would otherwise produce a popping sound, while allowing your voice to pass through with no noticeable reduction of volume or high frequencies. The double cloth filter blocks the pops and lets the voice through with no coloration. The metal clamp mount attaches to the mike stand secure enough to keep it attached. The goose neck needs a little coaxing to stay where you put it.\", \"overall\": 5.0, \"summary\": \"It Does The Job Well\", \"unixReviewTime\": 1377648000, \"reviewTime\": \"08 28, 2013\"}",
                                        "{\"reviewerID\": \"A27PF2GVKMJSAA\", \"asin\": \"B0002D0CQC\", \"reviewerName\": \"ultravega\", \"helpful\": [0, 0], \"reviewText\": \"The tips of my fingers often get pretty dry and cracked, especially when I've been playing a lot.  The problem, at least for me, is that pieces of the dead skins sometimes catch on guitar strings making slides, bends, and pull-offs less fluid.  A few strokes of GHS makes the fretboard give me a much smoother playing experience.  An alternative would be using Vaseline on my fingers, but that would probably be terrible for my fretboard.  Also, I sometimes use an Emory board to smooth my fingertips which helps, but I'd rather do that as little as possible to keep callouses strong.  GHS allows me to minimize that.\", \"overall\": 5.0, \"summary\": \"Use this to shread, great for cracked/dry finger tips\", \"unixReviewTime\": 1367884800, \"reviewTime\": \"05 7, 2013\"}",
                                        "{\"reviewerID\": \"A5I7XOLQRH9YE\", \"asin\": \"B0002F73YY\", \"reviewerName\": \"Corbin\", \"helpful\": [0, 0], \"reviewText\": \"It's great if you need to quickly drop your hats, but not the other way around. I bought this drop clutch because it was cheap, and I was on a budget. Overall its build is solid, the only problem I have with it is having the clutch lock back into place.\", \"overall\": 3.0, \"summary\": \"It's great if you want to quickly drop your hats, but not so good on coming back up.\", \"unixReviewTime\": 1384387200, \"reviewTime\": \"11 14, 2013\"}",
                                        "{\"reviewerID\": \"A22Z554ZQ8NFPC\", \"asin\": \"B0002F7IIK\", \"reviewerName\": \"AF Whigs\", \"helpful\": [0, 0], \"reviewText\": \"For years I've used the super-cheap rake hangers you can get at hardware stores - the metal U coated in rubber, with the heavy-duty screw end.  These are fine, except that some guitars don't want to fit, and recently when trying to widen the mouth of one the weld failed and so the U detached from the screw part.Well, that got me to thinking that I should find a better solution for hanging my guitars.  The thing is, I hate overpaying for things.  To me, $15-20 is way too much for a guitar hanger.  Sure, it's important to have something solid to hold our babies, but I want to feel like I'm getting some value.I bought 2 of these hangers, and they're rock-solid.  As others have said - put some good screws into a stud, don't bother with the hassle of the drywall anchors provided.  I just used some 2 drywall screws.  I like the simplicity of the metal plate that the yoke is attached to.  The U is easy to adjust for width, the retainer rings slide on very easily, and I've tried both acoustic and electric guitars and all hang away from the wall.No complaints - these are great, the quality seems excellent and $9 seems just about right to me.\", \"overall\": 5.0, \"summary\": \"Very nice!\", \"unixReviewTime\": 1330387200, \"reviewTime\": \"02 28, 2012\"}"
                                      };
        }

        [TestMethod]
        public void TestGenerate()
        {
            MarkovHelper markovHelper = new MarkovHelper();
            markovHelper.Ingest(this.sampleData);
            markovHelper.Chain = markovHelper.Train();

            ReviewController controller = new ReviewController(markovHelper);

            Review result = controller.Generate();

            // We have some expectations about the data contained in the review as to the datatype and the domain, to some extent.
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.reviewerID);
            Assert.IsTrue(result.reviewerID.Length > 0);
            Assert.IsNotNull(result.asin);
            Assert.IsTrue(result.asin.Length > 0);
            Assert.IsNotNull(result.reviewerName);
            Assert.IsTrue(result.reviewerName.Length > 0);
            Assert.IsNotNull(result.helpful);
            Assert.IsTrue(result.helpful[0] >= 0);
            Assert.IsTrue(result.helpful[1] >= 0);
            Assert.IsNotNull(result.reviewText);
            Assert.IsTrue(result.reviewText.Length > 0);
            Assert.IsNotNull(result.overall);
            Assert.IsTrue(result.overall.GetType() == typeof(decimal));
            Assert.IsTrue(result.overall >= 0 && result.overall <= 5);
            Assert.IsNotNull(result.summary);
            Assert.IsTrue(result.summary.Length > 0);
            Assert.IsNotNull(result.unixReviewTime);
            Assert.IsNotNull(result.reviewTime);
            Assert.IsTrue(DateTime.MinValue.AddSeconds(result.unixReviewTime) > DateTime.MinValue && DateTime.MinValue.AddSeconds(result.unixReviewTime) < DateTime.MaxValue);
            Assert.IsTrue(result.reviewTime > DateTime.MinValue && result.reviewTime < DateTime.MaxValue);
        }
    }
}
