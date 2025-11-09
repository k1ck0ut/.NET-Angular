// src/app/app.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService } from './todo.service';
import { Todo } from './todo.model';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  todos: Todo[] = [];
  newTitle = '';
  isLoading = false;
  error: string | null = null;

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.isLoading = true;
    this.error = null;

    this.todoService.getTodos().subscribe({
      next: (todos) => {
        this.todos = todos;
        this.isLoading = false;
      },
      error: () => {
        this.error = 'Error loading todos.';
        this.isLoading = false;
      },
    });
  }

  addTodo(): void {
    const title = this.newTitle.trim();
    if (!title) {
      return;
    }

    this.error = null;

    this.todoService.addTodo(title).subscribe({
      next: (todo) => {
        this.todos.push(todo);
        this.newTitle = '';
      },
      error: () => {
        this.error = 'Error adding todo.';
      },
    });
  }

  toggleTodo(todo: Todo): void {
    this.error = null;

    this.todoService.toggleTodo(todo.id).subscribe({
      next: (updated) => {
        if (updated && typeof updated.isDone === 'boolean') {
          todo.isDone = updated.isDone;
        } else {
          todo.isDone = !todo.isDone;
        }
      },
      error: () => {
        this.error = 'Error toggling todo.';
      },
    });
  }

  deleteTodo(todo: Todo): void {
    this.error = null;

    this.todoService.deleteTodo(todo.id).subscribe({
      next: () => {
        this.todos = this.todos.filter((t) => t.id !== todo.id);
      },
      error: () => {
        this.error = 'Error deleting todo.';
      },
    });
  }
}
