using System;
using Shouldly;
using Xunit;

namespace WatchListAnalysis.Tests
{



    public class WatchListAnalysisTests
    {
        [Fact]
        public void GetFiles_FileExists_ReturnsListOfFilesInFolder()
        {
            StubWatchListAnalysis _watchListAnalysis =  new StubWatchListAnalysis();
            _watchListAnalysis.filesToReturn = new string[] {   @"D:\CommSec\DataFiles\Watchlist_22102019.txt", 
                                                                @"D:\CommSec\DataFiles\Watchlist_20102019.txt" };

            var files = _watchListAnalysis.GetFiles(@"D:\CommSec\DataFiles");
            
            files.Length.ShouldBeGreaterThan(0);
            
            var expectedFileToReturn = @"D:\CommSec\DataFiles\Watchlist_22102019.txt";
            files.ShouldContain(expectedFileToReturn);
            files.ShouldContain(@"D:\CommSec\DataFiles\Watchlist_20102019.txt");
        }
    }
}
