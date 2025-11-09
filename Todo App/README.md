# Todo App (.NET 7 + Angular 20)

A simple Todo application with:

- **Backend:** .NET 7 minimal API
- **Frontend:** Angular 20 SPA

The app lets you create, toggle, and delete todo items.

---

## 1. Requirements

Before you start, make sure you have:

- **.NET 7 SDK** installed  
  You can check it with:

  dotnet --version

* **Node.js + npm** installed (LTS is recommended)
  Check with:

  node -v
  npm -v

* **Angular CLI 20** installed globally:

  npm install -g @angular/cli

Angular apps are served in development with the `ng serve` command on port **4200** by default. ([angular.dev][1])
The .NET minimal API runs with `dotnet run` and listens on a configured port (for example `http://localhost:5296`). ([learn.microsoft.com][2])

---

## 2. Project Structure

The repository is organized like this:

Todo App/
ToDo-app/ # Angular 20 frontend (SPA)
TodoApi/ # .NET 7 minimal API backend

---

## 3. How to Run the Backend (API)

1. Open a terminal (PowerShell, cmd or similar).

2. Navigate to the backend folder:

   ```powershell
   cd ".\Todo App\TodoApi"
   ```

3. Restore dependencies (optional but safe):

   ```powershell
   dotnet restore
   ```

4. Run the API:

   ```powershell
   dotnet run
   ```

5. After the API starts, you should see output in the terminal with the listening URLs, for example:

   Now listening on: http://localhost:5296

   Make sure this URL (especially the port) matches the one configured in the Angular service (`apiUrl`).

### API Endpoints

The backend exposes these endpoints:

- `GET    /api/todos`
  Returns all todo items.

- `POST   /api/todos`
  Creates a new todo.
  Request body (JSON):

  {
  "title": "My task",
  "isDone": false
  }

- `POST   /api/todos/{id}/toggle`
  Toggles the `isDone` state for a todo with the given `id`.

- `DELETE /api/todos/{id}`
  Deletes a todo with the given `id`.

Keep this terminal window **open** while testing the app – closing it will stop the API.

---

## 4. How to Run the Frontend (Angular)

1. Open another terminal window.

2. Navigate to the frontend folder:

   ```powershell
   cd ".\Todo App\ToDo-app"
   ```

3. Install dependencies (first time only):

   ```powershell
   npm install
   ```

4. Start the Angular dev server:

   ```powershell
   ng serve
   ```

   This compiles the app and starts a development server, usually on:

   ```text
   http://localhost:4200
   ```

   (If port 4200 is busy, Angular CLI can be configured to use another port, but by default it’s 4200.) ([Pinggy][3])

5. Keep this terminal window **open** too – closing it will stop the frontend dev server.

---

## 5. Opening the App in the Browser

Once both servers are running:

- **Backend:** `dotnet run` in `TodoApi` (for example on `http://localhost:5296`)
- **Frontend:** `ng serve` in `ToDo-app` (on `http://localhost:4200`)

Open your browser and go to:

```text
http://localhost:4200
```

You should see the Todo app page.

---

## 6. How to Use the Todo App

On the main screen you can:

1. **Add a new task**

   - Type a title into the input field (e.g. `Buy milk`).
   - Click the **“Add”** button.
   - The new task will appear in the list.

2. **Mark a task as done / not done**

   - Use the **checkbox** next to a task.
   - This sends a request to `POST /api/todos/{id}/toggle` on the backend.
   - The text of the completed task is usually styled as “done” (e.g. struck through).

3. **Delete a task**

   - Click the **✕** button next to a task.
   - This sends a `DELETE /api/todos/{id}` request to the backend.
   - The task disappears from the list.

If the backend is not running, you will see an error message in the UI when trying to load or modify todos.

---

## 7. Stopping the Application

To stop everything:

- Go to the terminal where `ng serve` is running and press `Ctrl + C`.
- Go to the terminal where `dotnet run` is running and press `Ctrl + C`.

After that:

- `http://localhost:4200` will no longer be available.
- The API (`http://localhost:5296` or your configured port) will also stop responding.

You can start both again at any time using the commands from sections **3** and **4**.

---

## 8. Optional: Basic Git Usage

If you want to work with this project in Git:

```bash
# Initialize (if the repo isn't already initialized)
git init

# Stage all files
git add .

# First commit
git commit -m "Initial commit: Todo App (.NET 7 + Angular 20)"
```

When you make changes:

```bash
git status           # See what changed
git add .            # Stage changes
git commit -m "Describe your change"
git push origin main # Push to remote (if configured)
```

```

```
