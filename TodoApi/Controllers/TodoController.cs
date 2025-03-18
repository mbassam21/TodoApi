using Microsoft.AspNetCore.Mvc;

using TodoApi.Models;

using System.Collections.Generic;

using System.Linq;



namespace TodoApi.Controllers

{

	    [Route("api/[controller]")]

		        [ApiController]

				    public class TodoController : ControllerBase

								      {

									              private static readonly List<TodoItem> Todos = new List<TodoItem>

											              {

													                  new TodoItem { Id = 1, Name = "Learn Docker", IsCompleted = false },

															                  new TodoItem { Id = 2, Name = "Build microservice", IsCompleted = false },

																	              new TodoItem { Id = 3, Name = "Deploy application", IsCompleted = false }

															          };



										              [HttpGet]

												              public ActionResult<IEnumerable<TodoItem>> GetTodos()

														              {

																                  return Ok(Todos);

																		          }



											              [HttpGet("{id}")]

													              public ActionResult<TodoItem> GetTodoById(long id)

															              {

																	                  var todo = Todos.FirstOrDefault(t => t.Id == id);

																			              if (todo == null)

																					                  {

																								                  return NotFound();

																										              }

																				                  return Ok(todo);

																						          }



												              [HttpPost]

														              public ActionResult<TodoItem> CreateTodo(TodoItem todo)

																              {

																		                  todo.Id = Todos.Max(t => t.Id) + 1;

																				              Todos.Add(todo);

																					                  return CreatedAtAction(nameof(GetTodoById), new { id = todo.Id }, todo);

																							          }



													              [HttpPut("{id}")]

															              public IActionResult UpdateTodo(long id, TodoItem todo)

																	              {

																			                  var existingTodo = Todos.FirstOrDefault(t => t.Id == id);

																					              if (existingTodo == null)

																							                  {

																										                  return NotFound();

																												              }



																						                  existingTodo.Name = todo.Name;

																								              existingTodo.IsCompleted = todo.IsCompleted;



																									                  return NoContent();

																											          }



														              [HttpDelete("{id}")]

																              public IActionResult DeleteTodo(long id)

																		              {

																				                  var todo = Todos.FirstOrDefault(t => t.Id == id);

																						              if (todo == null)

																								                  {

																											                  return NotFound();

																													              }



																							                  Todos.Remove(todo);

																									              return NoContent();

																										              }

															          }

}


