Projet AR — TP

Bienvenue dans le TP Projet AR ! L'idée : donner vie à de petits objets (cubes, sphères...),
les faire se déplacer, interagir et prendre des décisions simples.

Ce que nous avons déjà fait

- [x] Créer le projet à partir d’un template AR
- [x] Mettre le projet sur GitHub
- [x] Lancer et tester la scène de base
- [x] Ajouter de la physique au cube de base
- [x] Implémenter une logique de base pour le cube (partie 1)
- [x] Compléter la logique de base pour le cube (partie 2)

Ce qui reste à faire

Nous allons maintenant travailler sur le comportement autonome des cubes : ils
doivent pouvoir choisir une destination, vérifier sa validité, s'y déplacer et
parfois sauter.

Objectifs (checklist)

- [ ] Paramétrer les layers physiques
- [ ] Détecter et choisir une position valide pour se déplacer
- [ ] Créer une logique de prise de décision (toutes les X secondes)
- [ ] Appliquer de la force pour avancer vers la position choisie
- [ ] Faire sauter le cube de temps en temps

Notes & idées

- Tester le comportement avec plusieurs cubes simultanément
- Utiliser des raycasts ou des capteurs (colliders) pour vérifier la validité des positions
- Prévoir des protections contre des positions hors scène ou trop élevées
