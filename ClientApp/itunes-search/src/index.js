import 'bootstrap/dist/css/bootstrap.css';
import React from 'react';
import { render } from 'react-dom';
import { Provider } from 'react-redux';

import { store } from './components/Auth/Helpers/store';
import { App }  from './App';
// import { BrowserRouter } from 'react-router-dom';
// import registerServiceWorker from './serviceWorker';

// const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href');
//const rootElement = document.getElementById('app');

render (
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById('app')
);
// registerServiceWorker();

