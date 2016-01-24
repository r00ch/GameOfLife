using NUnit.Framework;

namespace GameOfLife.Tests
{
	[TestFixture]
	public class GameOfLifeAcceptanceTests
	{
		[SetUp]
		public void InvokeInstance()
		{
			game = new GameOfLife();
		}

		[Test, TestCaseSource("ImmortalLayouts")]
		public void Step_ImmortalCells(string[] coordinates)
		{
			game.Initialize(coordinates);

			var iterationOne = game.GetLifeCells(1);
			var iterationTwo = game.GetLifeCells(2);

			CollectionAssert.AreEquivalent(coordinates, iterationOne);
			CollectionAssert.AreEquivalent(coordinates, iterationTwo);
		}

		[Test, TestCaseSource("OscillatorLayouts")]
		public void Step_OscillatorLayouts(string[] state1, string[] state2)
		{
			game.Initialize(state1);

			var iterationOne = game.GetLifeCells(1);
			var iterationTwo = game.GetLifeCells(2);

			CollectionAssert.AreEquivalent(state2, iterationOne);
			CollectionAssert.AreEquivalent(state1, iterationTwo);
		}

		private static readonly object[] OscillatorLayouts =
		{
			//kreska
			new object[]
			{
				new[]{ "0x0", "1x0", "2x0"},
				new[]{ "1x1", "1x0", "1x-1"}
			},
		};
		private static readonly object[] ImmortalLayouts =
		{
			//klocek
			new object[] { new[]{
				"0x0", "1x0",
				"0x-1", "1x-1" }},
			//łódź
			new object[] { new[]
			{
				"0x0", "1x0",
				"0x-1", "2x-1",
				"1x-2"
			} },
			//koniczynka
			new object[] { new[]
			{
				"1x0",
				"0x-1", "2x-1",
				"1x-2"
			}},
			//kryształ
			new object[] { new[]
			{
				"1x0",
				"0x-1", "2x-1",
				"0x-2", "2x-2",
				"1x-3"
			}}
		};

		private IGameOfLife game;
	}
}
