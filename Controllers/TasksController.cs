using Microsoft.AspNetCore.Mvc;
using SimpleTaskTracker.Models;

namespace SimpleTaskTracker.Controllers;

public class TasksController : Controller
{
    // Demo storage only: data resets when the application restarts.
    private static readonly List<TaskItem> Tasks =
    [
        new() { Id = 1, Title = "Explore ASP.NET Core MVC", Description = "Understand models, views and controllers." },
        new() { Id = 2, Title = "Build a small project", Description = "Add and complete a task.", IsCompleted = true }
    ];

    private static int _nextId = 3;

    public IActionResult Index() => View(Tasks.OrderBy(t => t.IsCompleted).ToList());

    public IActionResult Create() => View(new TaskItem());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(TaskItem task)
    {
        if (!ModelState.IsValid) return View(task);

        task.Id = _nextId++;
        Tasks.Add(task);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        return task is null ? NotFound() : View(task);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, TaskItem updatedTask)
    {
        if (id != updatedTask.Id) return BadRequest();
        if (!ModelState.IsValid) return View(updatedTask);

        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task is null) return NotFound();

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.IsCompleted = updatedTask.IsCompleted;

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task is not null) Tasks.Remove(task);

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Toggle(int id)
    {
        var task = Tasks.FirstOrDefault(t => t.Id == id);
        if (task is not null) task.IsCompleted = !task.IsCompleted;

        return RedirectToAction(nameof(Index));
    }
}
