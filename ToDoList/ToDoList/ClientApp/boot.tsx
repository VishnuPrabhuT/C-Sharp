import './css/site.css';
import 'bootstrap';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import * as RoutesModule from './routes';
import { render } from 'react-dom';
let routes = RoutesModule.routes;

function renderApp() {
    // This code starts up the React app when it runs in a browser. It sets up the routing
    // configuration and injects the app into a DOM element.
    const baseUrl = document.getElementsByTagName('base')[0].getAttribute('href')!;
    return render(<AppContainer>
        <BrowserRouter children={routes} basename={baseUrl} />
    </AppContainer>,
        document.getElementById('react-app'));
}

renderApp();
var link = document.createElement('link');
link.id = 'id2';
link.rel = 'stylesheet';
link.href = 'https://use.fontawesome.com/releases/v5.1.0/css/all.css';
document.head.appendChild(link);
// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept('./routes', () => {
        routes = require<typeof RoutesModule>('./routes').routes;
        renderApp();
    });
}
