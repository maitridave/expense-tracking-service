import React from 'react';
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import UserManagement from './components/UserManagement';
import ExpenseTracking from './components/ExpenseTracking';

function App() {
  return (
    <Router>
      <div>
        <Switch>
          <Route path="/user-management" component={UserManagement} />
          <Route path="/expense-tracking" component={ExpenseTracking} />
          <Route path="/" exact>
            <h1>Welcome to My Expense Tracker</h1>
          </Route>
        </Switch>
      </div>
    </Router>
  );
}

export default App;