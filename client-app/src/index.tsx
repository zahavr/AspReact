import React from 'react';
import ReactDOM from 'react-dom';
import 'react-toastify/dist/ReactToastify.min.css';
import 'semantic-ui-css/semantic.min.css'
import 'react-calendar/dist/Calendar.css';
import 'react-datepicker/dist/react-datepicker.css'
import './app/layout/style.css';
import App from './app/layout/App';
import reportWebVitals from './reportWebVitals';
import {store, StoreContext} from './app/stores/store';
import { Router } from 'react-router-dom';
import {createBrowserHistory} from 'history'

export const history = createBrowserHistory();

ReactDOM.render(
    <StoreContext.Provider value={store}>
        <Router history={history}>
            <App />
        </Router>
    </StoreContext.Provider>,
    document.getElementById('root')
);

reportWebVitals();
