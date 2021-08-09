import React from 'react';
import ReactDOM from 'react-dom';
import 'semantic-ui-css/semantic.min.css'
import './app/layout/style.css';
import App from './app/layout/App';
import reportWebVitals from './reportWebVitals';
import {store, StoreContext} from './app/stores/store';
import { BrowserRouter } from 'react-router-dom';

ReactDOM.render(
    <StoreContext.Provider value={store}>
        <BrowserRouter>
            <App />
        </BrowserRouter>
    </StoreContext.Provider>,
    document.getElementById('root')
);

reportWebVitals();
