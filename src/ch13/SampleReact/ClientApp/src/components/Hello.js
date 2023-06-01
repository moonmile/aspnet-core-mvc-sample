import React, { Component } from 'react';

export class Hello extends Component {
    
    constructor(props) {
        super(props);
        this.state = { items: [] };
      }
  render() {
    this.peopleData()

    return (
      <div>
        <h1>HELLO React and ASP.NET Core</h1>
        <div>
            <table className="table">
            <thead>
                <tr>
                    <th>id</th>
                    <th>name</th>
                    <th>address</th>
                    <th>age</th>
                </tr>
            </thead>
            <tbody>
                {this.state.items.map(item =>
                <tr key={item.id}>
                    <td>{  item.id  }</td>
                    <td>{  item.name  }</td>
                    <td>{  item.address?.name  }</td>
                    <td>{  item.age  }</td>
                </tr>
                )}
            </tbody>
            </table>
        </div>
    </div>
  )}
  async peopleData() {
    const response = await fetch('https://localhost:5001/api/People');
    const data = await response.json();
    this.setState({ items: data });
  }
}
