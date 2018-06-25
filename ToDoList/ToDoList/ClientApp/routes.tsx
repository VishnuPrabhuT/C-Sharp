import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { FetchData } from './components/FetchData';
import { Counter } from './components/Counter';
import { ToDoList } from './components/ToDoList';

export const routes = <Layout>
    <Route exact path='/' component={ToDoList} />
    <Route path='/counter' component={Counter} />
    <Route path='/fetchdata' component={FetchData} />
</Layout>;
