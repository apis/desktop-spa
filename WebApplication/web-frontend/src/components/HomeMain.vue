<template>
  <div>
    <h1>Hello, world!</h1>
    <p>Welcome to your new single-page application, built with:</p>
    <ul>
      <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
      <li><a href='https://vuejs.org/'>Vue JS</a> for client-side code</li>
      <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
    </ul>
    <p>To help you get started, we have also set up:</p>
    <ul>
      <li><strong>Client-side navigation</strong>. For example, click <em>Counter</em> then <em>Back</em> to return here.</li>
      <li><strong>Development server integration</strong>. In development mode, the JS development server from from <code>web-frontend</code> subdirectory should be started manually by executing <code>npm run serve</code>, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
      <li><strong>Efficient production builds</strong>. In production mode, development-time features are disabled, and your <code>dotnet publish</code> configuration produces minified, efficiently bundled JavaScript files.</li>
    </ul>
    <p>The <code>web-frontend</code> subdirectory is a standard Vue JS application based on the <code>vue create</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm run build</code> or <code>npm install</code>.</p>
  </div>
</template>

<script>

export default {
  name: 'HomeMain'
}

</script>
