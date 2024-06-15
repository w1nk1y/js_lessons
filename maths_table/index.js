function multiply() {
    const entry = document.getElementById('entry').value;
    const div = document.getElementById('result');
  
    div.innerHTML = '';
 
    for (let i = 1; i <= 10; i++) {
      const p = document.createElement('p');
      p.textContent = `${entry} * ${i} = ${entry * i}`;
      div.appendChild(p);
    }
  }
  
  const button = document.getElementById('multiply');
  button.addEventListener('click', multiply);
  
