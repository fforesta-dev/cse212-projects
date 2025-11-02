using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities, then Dequeue.
    // Expected Result: Highest priority item ("High") should be removed first.
    // Defect(s) Found: Skipped last element and item not removed.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("Low", 1);
        pq.Enqueue("Medium", 3);
        pq.Enqueue("High", 5);

        string result = pq.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Two items with the same highest priority.
    // Expected Result: The first one enqueued among equals should be removed first.
    // Defect(s) Found: Used >= which removed the last of equal priority.
    public void TestPriorityQueue_FifoForSamePriority()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 5);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 4);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: None after fix.
    public void TestPriorityQueue_EmptyThrows()
    {
        var pq = new PriorityQueue();
        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }

    [TestMethod]
    // Scenario: Verify queue shrinks properly after dequeue.
    // Expected Result: Item removed from internal list.
    // Defect(s) Found: Item wasn’t removed in buggy version.
    public void TestPriorityQueue_LengthDecreases()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 3);

        pq.Dequeue();
        string result = pq.ToString();

        Assert.IsFalse(result.Contains("C"));
    }
}
