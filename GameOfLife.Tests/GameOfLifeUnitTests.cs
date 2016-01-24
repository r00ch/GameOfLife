using NUnit.Framework;
using System.Collections.Generic;

namespace GameOfLife.Tests
{
	[TestFixture]
    public class GameOfLifeUnitTests
    {
		[SetUp]
		public void Prepare()
		{
			game = new GameOfLife();
		}

		[Test]
		public void GetLifeCells_ReturnsInitializedCollection_WhenIterationIsZero()
		{
			var initAddresses = new string[] { "3x3" };
			game.Initialize(initAddresses);

			var lifeAddresses = game.GetLifeCells(0);

			CollectionAssert.AreEquivalent(initAddresses, lifeAddresses);
		}

		[Test]
		public void OneIteration_ReturnsEmptyCollectionOfLives_WhenWorldIsEmpty()
		{
			game.Initialize(new string[0]);

			var lifeAddresses = game.GetLifeCells(1);

			CollectionAssert.IsEmpty(lifeAddresses);
		}

		[TestCase("OneIsUnsufficient")]
		[TestCase("TwoIsAlsoUnsufficient")]
		public void OneIteration_CellsDieWhenTheyDoNotHaveSufficientNeighbours(string key)
		{
			game.Initialize(CoordinatesToDie[key]);

			var lifeAddresses = game.GetLifeCells(1);

			CollectionAssert.IsEmpty(lifeAddresses);
		}

		//x
		// s
		//  x
		[Test]
		public void Step_CellSurvives_WhenHas2Neighbours()
		{
			var initAddresses = new[] { "0x0", "1x1", "2x2" };
			var expectedAddresses = new[] { "1x1" };
			game.Initialize(initAddresses);

			var lifeAddresses = game.GetLifeCells(1);

			CollectionAssert.AreEquivalent(expectedAddresses, lifeAddresses);
		}

		// n
		//xsx
		// n
		[Test]
		public void Step_CellGeneratesNewCell_WhenHas3Neighbours()
		{
			var initAddresses = new[] { "0x0", "1x0", "2x0" };
			var expectedAddresses = new[] { "1x-1", "1x0", "1x1" };
			game.Initialize(initAddresses);

			var lifeAddresses = game.GetLifeCells(1);

			CollectionAssert.AreEquivalent(expectedAddresses, lifeAddresses);
		}


		static readonly Dictionary<string, string[]> CoordinatesToDie = new Dictionary<string, string[]>
		{
			{ "OneIsUnsufficient", new string[] { "0x0" } },
			{ "TwoIsAlsoUnsufficient", new string[] { "0x0", "1x0" } }
		};

		private IGameOfLife game;
	}
}
